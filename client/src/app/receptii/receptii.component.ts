import { IFurnizor } from './../shared/models/furnizor';
import { IReceptieInListDto } from './../shared/models/receptie';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ReceptieParams } from '../shared/models/receptie';
import { ReceptiiService } from './receptii.service';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { noop, Observable, Observer, of, Subscription } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { PageParams } from '../shared/models/pageParams';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-receptii',
  templateUrl: './receptii.component.html',
  styleUrls: ['./receptii.component.scss']
})
export class ReceptiiComponent implements OnInit, OnDestroy {

  receptieParams = new ReceptieParams();
  totalCount: number;
  receptii: IReceptieInListDto[];

  search?: string;
  suggestions$?: Observable<IFurnizor[]>;
  errorMessage?: string;
  selectedOption: IFurnizor;

  modificari: boolean;
  private sub : Subscription;

  constructor(private receptiiService: ReceptiiService, private toastr: ToastrService) { }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
    this.getReceptii();

    this.suggestions$ = new Observable((observer: Observer<string | undefined>) => {
      observer.next(this.search);
    }).pipe(
      switchMap((query: string) => {
        if (query) {
          return this.receptiiService.getFurnizori(query)
          .pipe(
            map((data: IFurnizor[]) => data || []),
            tap(() => noop, err => {
              // in case of http error
              this.errorMessage = err && err.message || 'Something goes wrong';
            })
          );
        }
 
        return of([]);
      })
    );

    this.sub = this.receptiiService.modificareReceptii$.subscribe(modificari => {
      this.modificari = modificari;

      if (this.modificari) {
        this.receptieParams.pageIndex = 1;
        this.getReceptii();
      }
    })
  }

  getReceptii() {
    this.receptiiService.getReceptii(this.receptieParams).subscribe(response => {
      this.receptii = response.data;
      this.receptieParams.pageIndex = response.pageIndex;
      this.receptieParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  onSelect(event: TypeaheadMatch) {
    this.selectedOption = event.item;
    this.receptieParams.furnizorId = this.selectedOption.id;
    this.receptieParams.pageIndex = 1;
    this.getReceptii();
  }

  onSearch() {
    this.receptieParams.pageIndex = 1;
    this.getReceptii();
  }

  onReset() {
    this.search = '';
    this.receptieParams.nrDoc = '';
    this.receptieParams.furnizorId = null;
    this.receptieParams.pageIndex = 1;
    this.getReceptii();
  }

  onLostFocus() {
    this.receptieParams.furnizorId = null;
  }

  onClear() {
    this.search = '';
  }

  onPageChanged(pageParams: PageParams) {
    if (this.receptieParams.pageIndex !== pageParams.pageNumber || this.receptieParams.pageSize !== pageParams.pageSize) {
      this.receptieParams.pageIndex = pageParams.pageNumber;
      this.receptieParams.pageSize = pageParams.pageSize;
      this.getReceptii();
    }
  }

  delete(id: number) {
    this.receptiiService.deleteReceptie(id).subscribe(() => {
      this.toastr.success('Receptia a fost stearsa !');
      this.getReceptii();
    })
  }

}


   
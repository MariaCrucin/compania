import { IClientDto } from './../../models/client';
import { switchMap, map, tap } from 'rxjs/operators';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { ClientiSharedService } from './../../services/clienti-shared.service';
import { noop, Observable, Observer, of } from 'rxjs';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';


@Component({
  selector: 'app-choose-client',
  templateUrl: './choose-client.component.html',
  styleUrls: ['./choose-client.component.scss']
})
export class ChooseClientComponent implements OnInit {

  @Input() firmaId: number;
  @Output() onSelectClient = new EventEmitter<number>();
  clienti$?: Observable<IClientDto[]>;
  errorMessage?: string;
  search: string;
  selectedOption: IClientDto;
  
  constructor(private clientiService: ClientiSharedService) { }

  ngOnInit(): void {
    this.clienti$ = new Observable((observer: Observer<string | undefined>) => {
      observer.next(this.search);
    }).pipe(
      switchMap((query: string) => {
        if (query) {
          return this.clientiService.getClienti(this.firmaId, query)
            .pipe(
              map((data: IClientDto[]) => data || []),
              tap(() => noop, err => {
                this.errorMessage = err && err.message || 'Ceva nu a mers !';
              })
            );
        }
        return of([]);
      })
    );
  }

  onKeyup() {
    // this.onSelectClient.emit(null);
  }

  onSelect(event: TypeaheadMatch) {
    this.selectedOption = event.item;
    this.search = this.selectedOption.den;
    this.onSelectClient.emit(this.selectedOption.id);
  }

}

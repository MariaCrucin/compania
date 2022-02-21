import { IReceptieDto, IReceptieDtoToSave } from './../../shared/models/receptie';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { ReceptiiService } from '../receptii.service';

@Component({
  selector: 'app-edit-receptie',
  templateUrl: './edit-receptie.component.html',
  styleUrls: ['./edit-receptie.component.scss']
})
export class EditReceptieComponent implements OnInit, OnDestroy {

  receptie: IReceptieDto;
  errors: string[];
  paramsSubscription: Subscription;

  constructor(private receptiiService: ReceptiiService,private activatedRoute: ActivatedRoute, private router: Router, private toastr: ToastrService) { }

  ngOnDestroy(): void {
    this.paramsSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.loadReceptie();
  }

  loadReceptie() {
    this.paramsSubscription = this.activatedRoute.params.subscribe(params => {
      this.receptiiService.getReceptie(params.id).subscribe(receptie => {
        this.receptie = receptie;
      })
    });
  }

  saveChanges(receptieDto: IReceptieDtoToSave) {
    this.receptiiService.updateReceptie(this.receptie.id, receptieDto).subscribe(() => {
      this.toastr.success('Receptia a fost modificata !');
      this.router.navigate(['/receptii']);
    }, error => {
        console.log(error);
        this.errors = error.errors;
        
    })
  }

}

import { FirmeService } from './firme/firme.service';
import { Component, OnInit } from '@angular/core';
import { IFirma } from './shared/models/firma';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Compania';
  firma$: Observable<IFirma>;

  constructor(private firmeService: FirmeService) {}

  ngOnInit(): void {
    localStorage.clear();
    this.firma$ = this.firmeService.firma$;
  }

  
}

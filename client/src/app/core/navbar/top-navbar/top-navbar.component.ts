import { Observable } from 'rxjs';
import { FirmeService } from './../../../firme/firme.service';
import { Component, OnInit } from '@angular/core';
import { NavbarsComunicationService } from '../navbars-comunication.service';
import { IFirma } from 'src/app/shared/models/firma';

@Component({
  selector: 'app-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.scss']
})
export class TopNavbarComponent implements OnInit {

  isTopNavCollapsed = false;
  isOpen = false;
  firma$: Observable<IFirma>;

  constructor(private service: NavbarsComunicationService, private firmeService: FirmeService) { }

  ngOnInit(): void {
    this.service.toggleSideNavbar.next(this.isOpen);
    this.firma$ = this.firmeService.firma$;
  }

  toggleOpen() {
    this.isOpen = !this.isOpen;
    this.service.toggleSideNavbar.next(this.isOpen);
  }

}

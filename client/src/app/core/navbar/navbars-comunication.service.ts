import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavbarsComunicationService {

  toggleSideNavbar = new Subject<boolean>();

  constructor() { }
}

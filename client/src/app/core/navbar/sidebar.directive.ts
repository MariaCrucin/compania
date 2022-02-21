import { Directive, HostBinding } from '@angular/core';
import { Subscription } from 'rxjs';
import { NavbarsComunicationService } from './navbars-comunication.service';

@Directive({
  selector: '[appSidebar]'
})
export class SidebarDirective {

  @HostBinding('class.toggled') isOpen = false;
  toggledSub: Subscription;

  constructor(private service: NavbarsComunicationService) { }
  
  ngOnInit() {
    this.toggledSub = this.service.toggleSideNavbar.subscribe( isOpen => { this.isOpen = isOpen });
  }

  ngOnDestroy() {
    this.toggledSub.unsubscribe();
  }
}

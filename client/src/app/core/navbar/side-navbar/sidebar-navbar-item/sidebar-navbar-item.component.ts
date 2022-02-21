import { Component, Input, OnInit } from '@angular/core';
import { IMenuitem } from 'src/app/shared/models/menuitem';

@Component({
  selector: 'app-sidebar-navbar-item',
  templateUrl: './sidebar-navbar-item.component.html',
  styleUrls: ['./sidebar-navbar-item.component.scss']
})
export class SidebarNavbarItemComponent implements OnInit {

  @Input ("menuItem") menuItem: IMenuitem;

  icon;
  hasChildrens = false;
  opacity: number;
  backgroundColor: string;
  styleLink;
  style;

  constructor() { }

  ngOnInit(): void {
    this.opacity = 0 + this.menuItem.opacity / 20;
    this.backgroundColor = "rgba(0, 0, 0, " + this.opacity + ")";

    this.style = {
      "background-color": `rgb(155,155,155,${this.menuItem.opacity/10})`,
    };

    this.styleLink = {
      "background-color": `rgb(155,155,155,${this.opacity+0.1})`,
    };

    if (this.menuItem.children.length > 0) {
      this.hasChildrens = true;
    }
  }

}

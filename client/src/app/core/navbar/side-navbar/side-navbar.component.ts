import { Component, OnInit } from '@angular/core';
import { IMenuitem } from 'src/app/shared/models/menuitem';

@Component({
  selector: 'app-side-navbar',
  templateUrl: './side-navbar.component.html',
  styleUrls: ['./side-navbar.component.scss']
})
export class SideNavbarComponent implements OnInit {

  title = "dynamic-sidebar-menu";
  finalMenu: any[] = [];
  menuLoaded: Boolean = false;
  menu!: IMenuitem[];

  constructor() { }

  ngOnInit(): void {
    this.menu = [
      
        // ultimul id = 7

        {
          id: "1",
          text: "Stocuri",
          action: undefined,
          icon: "fas fa-fan",
          menuFatherId: undefined,
          opacity: undefined,
          children: undefined,
          isCollapsed:undefined,
        },
  
        {
          id: "2",
          text: "Receptii",
          action: "/receptii",
          icon: "fas fa-file-invoice",
          menuFatherId: "1",
          opacity: undefined,
          children: undefined,
          isCollapsed:undefined,
        },
      
        /******************************/

        {
          id: "3",
          text: "Clienti",
          action: undefined,
          icon: "fas fa-fan",
          menuFatherId: undefined,
          opacity: undefined,
          children: undefined,
          isCollapsed:undefined,
        },

        {
          id: "4",
          text: "Lista Clienti",
          action: "/clienti",
          icon: "fas fa-handshake",
          menuFatherId: "3",
          opacity: undefined,
          children: undefined,
          isCollapsed:undefined,
        },
  
        {
          id: "4",
          text: "Magazine",
          action: "/magazine",
          icon: "fas fa-store-alt",
          menuFatherId: "3",
          opacity: undefined,
          children: undefined,
          isCollapsed:undefined,
        },
        
        {
          id: "6",
          text: "Servicii",
          action: "/servicii",
          icon: "fas fa-cogs",
          menuFatherId: "3",
          opacity: undefined,
          children: undefined,
          isCollapsed:undefined,
        },

        {
          id: "7",
          text: "Tarife",
          action: "/tarife",
          icon: "fas fa-money-check-alt",
          menuFatherId: "3",
          opacity: undefined,
          children: undefined,
          isCollapsed:undefined,
        },

      
     
    ];
    this.renderMenu(this.menu);
  }

  renderMenu(menu: IMenuitem[]) {
    while (menu.length > 0) {
      for (var i = 0; i < menu.length;) {
        let menuItem = menu[i];
        menuItem.children = [];

        if (!menuItem.menuFatherId) {
          menu.splice(i, 1);
          menuItem.opacity = 0;
          this.finalMenu.push(menuItem);

          // i++;
          i=0;
        } else {
          const father = menuItem.menuFatherId;
          this.searchFather(this.finalMenu, father, menuItem, menu);
          
          // i++;
          i=0;
        }
      };
    }
    this.menuLoaded = true;
  }

  searchFather(menuArray: IMenuitem[], father, menuItem: IMenuitem, menu) {
    menuArray.forEach((menuPainted) => {
      if (menuPainted.id === father) {
        menuItem.opacity = menuPainted.opacity + 1;
        menuPainted.children.push(menuItem);

        const index: number = menu.indexOf(menuItem);
        if (index !== -1) {
          menu.splice(index, 1);
        }
      } else {
        this.searchFather(menuPainted.children, father, menuItem, menu);
      }
    });
  }

}

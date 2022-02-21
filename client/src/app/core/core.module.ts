import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastrModule } from 'ngx-toastr';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TopNavbarComponent } from './navbar/top-navbar/top-navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SideNavbarComponent } from './navbar/side-navbar/side-navbar.component';
import { SidebarNavbarItemComponent } from './navbar/side-navbar/sidebar-navbar-item/sidebar-navbar-item.component';
import { SidebarDirective } from './navbar/sidebar.directive';

@NgModule({
  declarations: [
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TopNavbarComponent,
    SideNavbarComponent,
    SidebarNavbarItemComponent,
    SidebarDirective,
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    RouterModule,
    CollapseModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    })
  ],
  exports: [
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TopNavbarComponent,
    SideNavbarComponent,
    SidebarNavbarItemComponent,
    SidebarDirective,
  ]
})
export class CoreModule { }

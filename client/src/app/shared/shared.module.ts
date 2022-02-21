import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { TextInputComponent } from './components/text-input/text-input.component';
import { NumberInputComponent } from './components/number-input/number-input.component';
import { TextInputUppercaseComponent } from './components/text-input-uppercase/text-input-uppercase.component';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { FormFurnizorComponent } from './components/furnizor/form-furnizor/form-furnizor.component';
import { DateInputComponent } from './components/date-input/date-input.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TextInputFluComponent } from './components/text-input-flu/text-input-flu.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ChooseClientComponent } from './components/choose-client/choose-client.component';



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    TextInputComponent,
    TextInputUppercaseComponent,
    NumberInputComponent,
    FormFurnizorComponent,
    DateInputComponent,
    TextInputFluComponent,
    ChooseClientComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CarouselModule.forRoot(),
    PaginationModule.forRoot(),
    TypeaheadModule.forRoot(),
    BsDatepickerModule.forRoot(),
    SweetAlert2Module.forRoot()
  ],
  exports: [
    CarouselModule,
    PaginationModule,
    FormsModule,
    ReactiveFormsModule,
    PagingHeaderComponent,
    PagerComponent,
    TextInputComponent,
    TextInputUppercaseComponent,
    TextInputFluComponent,
    NumberInputComponent,
    TypeaheadModule,
    FormFurnizorComponent,
    DateInputComponent, 
    BsDatepickerModule,
    SweetAlert2Module,
    ChooseClientComponent
  ]
})
export class SharedModule { }

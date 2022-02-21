import { PageParams } from './../../models/pageParams';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {
  pageParams = new PageParams();
  currentPage = 1;

  @Input() pageSize: number;
  @Input() totalCount: number;
  @Output() pageChanged = new EventEmitter<PageParams>();

  constructor() { }

  ngOnInit(): void {
  }

  onPagerChange(event: any) {
    this.pageParams.pageNumber = event.page;
    this.pageChanged.emit(this.pageParams);
  }

  onPagerSizeChange(pageSizeChoosed: number) {
    this.pageSize = pageSizeChoosed;

    this.pageParams.pageNumber = 1;
    this.pageParams.pageSize = pageSizeChoosed;

    this.pageChanged.emit(this.pageParams);
  }

}

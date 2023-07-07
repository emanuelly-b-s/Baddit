import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ForumService } from 'src/app/services/forum.service';

/**
 * @title Toolbar overview
 */
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent {
  constructor(
    private forum: ForumService,
    private router: Router
  ) {}



  forumSearch: string = '';


  search()
  {
    console.log('teste', this.forumSearch)
    this.forum.searchForum(this.forumSearch).subscribe((res) => {
      console.log(res)
    })
  }

}

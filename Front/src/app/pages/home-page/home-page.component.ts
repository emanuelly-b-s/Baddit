import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InfoForum } from 'src/app/DTO/Forum/InfoForum';
import { ListParticipantsForum } from 'src/app/DTO/Forum/ParticipantForum';
import { User } from 'src/app/DTO/User/User';
import { ForumService } from 'src/app/services/forum.service';
import { UserService } from 'src/app/services/users.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent implements OnInit {
  forums: InfoForum[] = [];

  constructor(
    private userService: UserService,
    private router: Router,
    private ForumService: ForumService
  ) {}

  authenticated: boolean = true;

  user: User = {
    userId: 0,
    username: '',
    email: '',
    photouser: 0,
    nickUser: '',
  };

  idForum: number = 0;

  goForum() {
    this.router.navigate(['/forum'], { queryParams: { id: this.idForum } });
  }

  ngOnInit(): void {
    let jwt = sessionStorage.getItem('jwtSession') ?? '';

    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
        this.user = res;

        this.userService.getForums(this.user).subscribe((list) => {
          console.log(list);
          var newList: InfoForum[] = [];
          list.forEach((element) => {
            newList.push({
              forumName: element.forumName,
              id: element.id,
              creator: element.creator,
              descriptionForum: element.descriptionForum,
            });
          });
          this.forums = newList;
        });
      },
    });
  }
}
// import { Component} from "@angular/core";
// @Component({
//   selector: "like-dislike",
//   template: `
//   <div>

// <button (click)="likeButtonClick()" [ngClass]="chooseclassl ? 'like-button' : 'liked'"> Like | {{numberOfLikes}} </button>
// <button (click)="dislikeButtonClick()" [ngClass]="chooseclassd ? 'dislike-button' : 'disliked'"> Dislike | {{numberOfDislike}} </button>

//   </div>
// `,

// styles:[`
//   .like-button,.dislike-button {
//     font-size: 1rem;
//     padding: 5px 10px;
//     color: #585858;
//   }
// .liked, .disliked {
//   font-weight: bold;
//   color:#1565c0;
// }
//   `]
// })
// export class LikeDislikeComponent {
//   numberOfLikes : number=100;
//   numberOfDislike: number=25;
//   chooseclassl:boolean = true;
//   chooseclassd:boolean = true;

//   likeButtonClick() {
//     if (this.likesCounter === true && this.dislikeCounter === true) {
//       this.numberOfLikes++;
//       this.likesCounter = false;
//     } else if (this.likesCounter === true && this.dislikeCounter === false) {
//       this.numberOfLikes++;
//       this.likesCounter = false;
//       this.numberOfDislike--;
//       this.dislikeCounter = true;
//     } else if (this.likesCounter === false && this.dislikeCounter === true) {
//       this.numberOfLikes--;
//       this.likesCounter = true;
//     }
//   }
//   dislikeButtonClick() {
//     if (this.dislikeCounter === true && this.likesCounter === true) {
//       this.numberOfDislike++;
//       this.dislikeCounter = false;
//     } else if (this.dislikeCounter === true && this.likesCounter === false) {
//       this.numberOfDislike++;
//       this.numberOfLikes--;
//       this.dislikeCounter = false;
//       this.likesCounter = true;
//     } else if (this.dislikeCounter === false && this.likesCounter === true) {
//       this.numberOfDislike--;
//       this.dislikeCounter = true;
//     }
//   }

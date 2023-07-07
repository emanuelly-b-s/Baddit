import { UserService } from '../../services/users.service';
import { Component, Input } from '@angular/core';
import { Post } from 'src/app/DTO/Post.ts/Post';
import { UpDown } from '../../DTO/UpvoteDownvote';
import { UpDownService } from '../../services/upDown.service';
import { User } from '../../DTO/User/User';
import { PostService } from 'src/app/services/post.service';
import { ListParticipantsForum } from 'src/app/DTO/Forum/ParticipantForum';
import { ForumService } from 'src/app/services/forum.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css'],
})
export class CardComponent {
  @Input() post: Post = {
    id: 0,
    tittle: '',
    postText: '',
    postDate: new Date(),
    forum: 0,
    participant: 0,
    upvote: 0,
    downvote: 0,
  };

  @Input() qtdUpvote: number = 0;

  constructor(
    private upDownService: UpDownService,
    private userService: UserService,
    private postService: PostService,
    private forumService: ForumService
  ) {}

  upDown: UpDown = {
    participant: 0,
    post: 0,
  };

  user: User = {
    userId: 0,
    username: '',
    nickUser: '',
    email: '',
    photouser: 0,
  };

  listParticipant: ListParticipantsForum = {
    forum: 0,
    Participant: 0
  };

  addUpDown() {
    this.upDown.post = this.post.id;
    this.upDown.participant = this.user.userId;

    this.upDownService.addUpDown(this.upDown).subscribe((res: any) => {
      console.log(res);
    });
  }

  followForum() {
    this.listParticipant.forum = this.post.forum;
    this.listParticipant.Participant = this.user.userId;

    this.forumService.addUser(this.listParticipant).subscribe((res: any) => {
      console.log(res);
    });
  }
  ngOnInit(): void {
    let jwt = sessionStorage.getItem('jwtSession') ?? '';

    this.userService.getUserLoggedIn({ valueToken: jwt }).subscribe({
      next: (res: User) => {
        this.user = res;
      },
    });
  }
}

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ForumRegister } from 'src/app/DTO/Forum/ForumRegister';
import { ForumService } from 'src/app/services/forum.service';
import { UserService } from 'src/app/services/users.service';

@Component({
  selector: 'app-forum-register',
  templateUrl: './forum-register.component.html',
  styleUrls: ['./forum-register.component.css'],
})
export class ForumRegisterComponent {
  constructor(
    private fb: FormBuilder,
    private forum: ForumService,
    private userService: UserService,
    private router: Router
  ) {}

  form: FormGroup = this.fb.group({
    
    forumName: ['', [Validators.required, Validators.minLength(2)]],
    descriptionForum: [
      '',
      [
        Validators.required,
        Validators.minLength(25),
        Validators.maxLength(120),
      ],
    ],
  });

  forumRegister: ForumRegister = {
    owner: 0,
    forumName: '',
    descriptionForum: '',
  };
  idOwner: number = 0;


  ngOnInit(): void {
    this.userService.validateUser().subscribe((res) => {
      if (!res.authenticated) {
        this.router.navigate(['/']);
      }
      this.idOwner = res.idUser;
      console.log(res);
    });
  }

  register() {
    this.forumRegister = { ...this.form.value };
    this.forumRegister.owner = this.idOwner;
    console.log(this.forumRegister);
        
    this.forum.add(this.forumRegister).subscribe((res) => {
      console.log(res);
    });
  }
}

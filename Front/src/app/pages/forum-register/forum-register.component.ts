import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Forum } from 'src/app/DTO-front/Forum';
import { ForumService } from 'src/app/services/forum.service';

@Component({
  selector: 'app-forum-register',
  templateUrl: './forum-register.component.html',
  styleUrls: ['./forum-register.component.css'],
})
export class ForumRegisterComponent {
  constructor(private fb: FormBuilder, private forum: ForumService) {}

  form: FormGroup = this.fb.group({
    forumName: ['', [Validators.required, Validators.minLength(2)]],
    descriptionForum: [
      '',
      [
        Validators.required,
        Validators.minLength(25),
        Validators.maxLength(120),
      ]
    ],
  });

  forumRegister: Forum = {
    forumName: '',
    descriptionForum: ''
  };

  register()
  {
    this.forumRegister = {...this.form.value};

    console.log(this.forumRegister);
    console.log(this.form.value);


    this.forum.add(this.forumRegister).subscribe(res =>
      {
        console.log('a');
      });

  }

}

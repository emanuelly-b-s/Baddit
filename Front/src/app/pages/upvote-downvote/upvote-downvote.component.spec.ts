import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpvoteDownvoteComponent } from './upvote-downvote.component';

describe('UpvoteDownvoteComponent', () => {
  let component: UpvoteDownvoteComponent;
  let fixture: ComponentFixture<UpvoteDownvoteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpvoteDownvoteComponent]
    });
    fixture = TestBed.createComponent(UpvoteDownvoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

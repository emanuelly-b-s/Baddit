import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumRegisterComponent } from './forum-register.component';

describe('ForumRegisterComponent', () => {
  let component: ForumRegisterComponent;
  let fixture: ComponentFixture<ForumRegisterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ForumRegisterComponent]
    });
    fixture = TestBed.createComponent(ForumRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

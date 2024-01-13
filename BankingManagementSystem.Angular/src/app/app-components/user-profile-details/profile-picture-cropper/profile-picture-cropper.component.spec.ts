import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilePictureCropperComponent } from './profile-picture-cropper.component';

describe('ProfilePictureCropperComponent', () => {
  let component: ProfilePictureCropperComponent;
  let fixture: ComponentFixture<ProfilePictureCropperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfilePictureCropperComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfilePictureCropperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

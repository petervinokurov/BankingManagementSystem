import { Component, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Store } from '@ngrx/store';
import { Dimensions, ImageCroppedEvent, ImageTransform } from 'ngx-image-cropper';
import { UpdateProfilePhotoCommand } from 'src/app/app-requests/updateProfilePhotoRequest';
import { updateUserProfilePhoto } from 'src/app/app-state/app.actions';

@Component({
  selector: 'app-profile-picture-cropper',
  templateUrl: './profile-picture-cropper.component.html',
  styleUrls: ['./profile-picture-cropper.component.scss']
})
export class ProfilePictureCropperComponent {
  @Input() profilePicture: string | undefined;

  imageChangedEvent: any = '';
  croppedImage: any = '';
  showCropper = false;
  transform: ImageTransform = {
    translateUnit: 'px'
  };
  updateProfilePhotoCommand: UpdateProfilePhotoCommand = {userId: "", photo: ""};

  constructor(private sanitizer: DomSanitizer,
    private readonly store: Store
  )
  {
  }

  fileChangeEvent(event: any): void {
    this.imageChangedEvent = event;
  }

  imageCropped(event: ImageCroppedEvent) {
    this.croppedImage = this.sanitizer.bypassSecurityTrustUrl(event.objectUrl || event.base64 || '');
    console.log(event);
  }

  imageLoaded() {
    this.showCropper = true;
  }

  cropperReady(sourceImageDimensions: Dimensions) {
  }

  loadImageFailed() {
  }

  onSavePhoto(){
    console.log(this.croppedImage);
    this.updateProfilePhotoCommand.photo = this.croppedImage;
    console.log(this.updateProfilePhotoCommand.photo);

    this.store.dispatch(updateUserProfilePhoto({command : this.updateProfilePhotoCommand}));
  }
}

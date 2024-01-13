import { Component, Input } from '@angular/core';
import { ImageCroppedEvent } from 'ngx-image-cropper';

@Component({
  selector: 'app-profile-picture-cropper',
  templateUrl: './profile-picture-cropper.component.html',
  styleUrls: ['./profile-picture-cropper.component.scss']
})
export class ProfilePictureCropperComponent {
  @Input() profilePicture: string | undefined;

  imageChangedEvent: any = '';
  croppedImage: any = '';

  fileChangeEvent(event: any): void {
      this.imageChangedEvent = event;
  }
  imageCropped(event: ImageCroppedEvent) {
    console.log('image cropped');
    this.croppedImage = event.base64;
  }

  imageLoaded() {
    console.log('show cropper');
  }

  cropperReady() {
    console.log('cropper ready');
  }
  loadImageFailed() {
    console.log('show message');
  }
}

import { Component, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Dimensions, ImageCroppedEvent, ImageTransform } from 'ngx-image-cropper';

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

  constructor(private sanitizer: DomSanitizer)
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
}

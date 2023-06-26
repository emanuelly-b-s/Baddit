import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ImageService } from '../../services/image.service';


@Component({
  selector: 'app-uploader',
  templateUrl: './uploader.component.html',
  styleUrls: ['./uploader.component.css'],
})
export class UploaderComponent implements OnInit {
  progress: number = 0;
  message: string = '';
  @Output() public onUploadFinished = new EventEmitter<any>();

  constructor(private service: ImageService) {}
  ngOnInit() {}

  uploadFile(files: any)
  {
    if (files.length === 0)
      return;

    let fileToUpload = <File>files[0];
    this.service.upload(fileToUpload, (result : any) =>
    {
      this.onUploadFinished.emit(result)
    })
  }
}

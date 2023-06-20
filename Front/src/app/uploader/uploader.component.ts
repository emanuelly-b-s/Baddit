import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-uploader',
  templateUrl: './uploader.component.html',
  styleUrls: ['./uploader.component.css']
})
export class UploaderComponent implements OnInit {
  progress: number = 0;
  message: string = "";
  @Output() public onUploadFinished = new EventEmitter<any>();
  
  constructor(private http: HttpClient) { }
  ngOnInit() {
  }
  uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    
    this.http.post('$initialCatalog = "FullExample"/img', formData)
      .subscribe(result =>
      {
        this.onUploadFinished.emit(result)
      });
  }
}


import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HttpService } from './services/http.service';
import { ImageViewModel, ResultViewModel } from './models/Image';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  fileNameToUpload = '';
  filesLoaded: ImageViewModel[] = [];


  constructor(private readonly _httpService: HttpService){
  }

  ngOnInit(): void {
    this._httpService.listImages()
      .subscribe(
        (result) => {this.filesLoaded = result.result; console.log(this.filesLoaded); },
        (error) => console.log(error)
      );
  }

  onFileSelected(event: any) {

    const file:File = event.target.files[0];

    if (!file)
      return;
    
    var reader = new FileReader();
    reader.readAsDataURL(file);

    reader.onload = () => {
      this._httpService.uploadImage({ Base64Image: reader.result as string})
      .subscribe(
        (result) => this._httpService.listImages()
          .subscribe(
            (result) => {this.filesLoaded = result.result; console.log(this.filesLoaded); },
            (error) => console.log(error)
          ), 
        (error) => console.log(error)
      );
    };
  }
}

import { Injectable } from '@angular/core';
import { ImageDTO, ImageViewModel, ResultViewModel, ResultViewModelWithoutResult } from '../models/Image';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { endpoints } from '../data/constants/api-constants';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private readonly _http: HttpClient) 
  { 
    
  }

  uploadImage(dto: ImageDTO): Observable<ResultViewModelWithoutResult>{
    return this._http.post<ResultViewModelWithoutResult>(endpoints.baseApiUrl + endpoints.image.upload, {
      ...dto
    });
  }

  listImages(): Observable<ResultViewModel<ImageViewModel[]>>{
    return this._http.get<ResultViewModel<ImageViewModel[]>>(endpoints.baseApiUrl + endpoints.image.list);
  }

}

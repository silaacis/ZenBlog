import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { blogDto } from '../_models/blog';
import { Result } from '../_models/result';

@Injectable({
  providedIn: 'root',
})
export class BlogService {
  constructor(private http: HttpClient) {
  }

  baseUrl = "https://localhost:7000/api/blogs/"

  getAll(){
    return this.http.get<Result<blogDto[]>>(this.baseUrl);
  }

  getLatest5Blogs(){
    return this.http.get<Result<blogDto[]>>(this.baseUrl+"latest5blogs")
  }

  create(model:blogDto){
    return this.http.post<Result<blogDto>>(this.baseUrl,model);
  }

  update(model:blogDto){
    return this.http.put(this.baseUrl,model);
  }

  delete(id:string){
    return this.http.delete(this.baseUrl+id);
  }

  getBlogById(id:string){
    return this.http.get<Result<blogDto>>(this.baseUrl+id)
  }
}

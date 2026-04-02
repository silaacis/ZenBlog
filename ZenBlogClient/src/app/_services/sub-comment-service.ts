import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SubCommentDto } from '../_models/subCommentDto';
import { Result } from '../_models/result';

@Injectable({
  providedIn: 'root',
})
export class SubCommentService {
constructor(private http:HttpClient){}

  baseUrl = "https://localhost:7000/api/subcomments/"

  create(model:SubCommentDto){
    return this.http.post<Result<SubCommentDto>>(this.baseUrl, model);
  }

  getAll(){
    return this.http.get<Result<SubCommentDto[]>>(this.baseUrl);
  }

  update(model:SubCommentDto){
    return this.http.put(this.baseUrl,model);
  }

  delete(id:string){
    return this.http.delete(this.baseUrl+id);
  }

  getById(id:string){
    return this.http.get<Result<SubCommentDto>>(this.baseUrl+id)
  }
}

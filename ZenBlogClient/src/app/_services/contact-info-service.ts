import { ContactInfoDto } from './../_models/contactInfoDto';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Result } from '../_models/result';

@Injectable({
  providedIn: 'root',
})
export class ContactInfoService {
  constructor(private http:HttpClient){}

  baseUrl = "https://localhost:7000/api/contactInfos/"

    create(model:ContactInfoDto){
      return this.http.post<Result<ContactInfoDto>>(this.baseUrl, model);
    }

    getAll(){
      return this.http.get<Result<ContactInfoDto[]>>(this.baseUrl);
    }

    update(model:ContactInfoDto){
      return this.http.put(this.baseUrl,model);
    }

    delete(id:string){
      return this.http.delete(this.baseUrl+id);
    }

    getById(id:string){
      return this.http.get<Result<ContactInfoDto>>(this.baseUrl+id)
    }
}

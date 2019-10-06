import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseAuthor } from '../authors.model/authors.model';
import { Observable } from 'rxjs';
import { ReqCreateAuthor, RespCreateAuthor } from '../authors.model/create.authors.model';
import { RespGetUpdateAuthor, ReqUpdateAuthor, RespUpdateAuthor } from '../authors.model/update.authors.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  private url = "http://localhost:5000/v1";

  constructor(private http:HttpClient) { }

  getMusic(): Observable<ResponseAuthor>{
    return this.http.get<ResponseAuthor>(this.url);
  };
 
  
  getAvailable(id:string):Observable<ResponseAuthor>{
    let _url =`${this.url}/musicauthorsavailable/${id}`;
    return this.http.get<ResponseAuthor>(_url);
  }

  getByName(id: string):Observable<ResponseAuthor>{
    
    let _url = "";
    if(id=="")
    {
      _url = `${this.url}/authors`;
    }else{
      
      _url = `${this.url}/authorsbyname/${id}`;
    }
    
    return this.http.get<ResponseAuthor>(_url);
  };

  create(req:ReqCreateAuthor):Observable<RespCreateAuthor>{
    let _url = `${this.url}/authors`;
    return this.http.post<RespCreateAuthor>(_url,req);
  };

  getById(id:string):Observable<RespGetUpdateAuthor>{
    let _url =`${this.url}/authors/${id}`;
    return this.http.get<RespGetUpdateAuthor>(_url);
  }

  update(id:string, req: ReqUpdateAuthor): Observable<RespUpdateAuthor>{
    let _url = `${this.url}/authors`;
    return this.http.put<RespUpdateAuthor>(_url,req);
  }

  delete(id: string): Observable<RespUpdateAuthor>{
    let _url =`${this.url}/authors/${id}`;
    return this.http.delete<RespUpdateAuthor>(_url);
  }
}

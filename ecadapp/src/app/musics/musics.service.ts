import { Injectable } from '@angular/core';
import { Observable, observable } from 'rxjs';
import { ResponseMusic } from "./music.model/ResponseMusic";
import { HttpClient} from '@angular/common/http';
import { ReqCreateMusic, RespCreateMusic } from './music.model/create.music.model';
import { RespUpdateMusic, RespGetMusic, ReqUpdateMusic } from './music.model/update.music.model';

@Injectable({
  providedIn: 'root'
})
export class MusicsService {

  private url = "http://localhost:5000/v1";

  constructor(private http:HttpClient) { }

  getMusic(): Observable<ResponseMusic>{
    return this.http.get<ResponseMusic>(this.url);
  };

  getMusicName(id: string):Observable<ResponseMusic>{
    
    let _url = "";
    if(id=="")
    {
      _url = `${this.url}/musics`;
    }else{
      
      _url = `${this.url}/musicsbyname/${id}`
    }
    
    return this.http.get<ResponseMusic>(_url);
  };

  createMusic(req:ReqCreateMusic):Observable<RespCreateMusic>{
    let _url = `${this.url}/musics`;
    return this.http.post<RespCreateMusic>(_url,req);
  };

  getMusicById(id:string):Observable<RespGetMusic>{
    let _url =`${this.url}/musics/${id}`;
    return this.http.get<RespGetMusic>(_url);
  }

  updateMusic(id:string, req: ReqUpdateMusic): Observable<RespUpdateMusic>{
    
    let _url = `${this.url}/musics`;
    return this.http.put<RespUpdateMusic>(_url,req);
  }

  deleteMusic(id: string): Observable<RespUpdateMusic>{
    let _url =`${this.url}/musics/${id}`;
    return this.http.delete<RespUpdateMusic>(_url);
  }
}

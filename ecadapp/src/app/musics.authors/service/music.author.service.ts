import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MusicAuthorResult, ResponseAuthorResult } from '../music-author.model/music-author.model';
import { ReqCreateMusicAuthor, RespCreateMusicAuthor } from '../music-author.model/create.music-author.model';
import { RespUpdateMusicAuthor, ReqUpdateMusicAuthor } from '../music-author.model/delete-music.author.model';

@Injectable({
  providedIn: 'root'
})
export class MusicAuthorService {

  
  private url = "http://localhost:5000/v1";

  constructor(private http:HttpClient) { }

  
  getById(id:string):Observable<ResponseAuthorResult>{
    let _url =`${this.url}/musics/${id}/authors`;

    return this.http.get<ResponseAuthorResult>(_url);
  }

  create(req:ReqCreateMusicAuthor):Observable<RespCreateMusicAuthor>{
    let _url =`${this.url}/musicsauthors`;
    return this.http.post<RespCreateMusicAuthor>(_url,req);
  };

  getMusicAuthorByIds(musicid:string, authorid:string):Observable<RespUpdateMusicAuthor>{
    let _url =`${this.url}/musicsauthorsbyid/${musicid}/${authorid}`;
    return this.http.get<RespUpdateMusicAuthor>(_url);
  };

  delete(musicid:string, authorid:string): Observable<RespUpdateMusicAuthor>{
    let _url =`${this.url}/deletemusicsauthors/${musicid}/${authorid}`;
    return this.http.delete<RespUpdateMusicAuthor>(_url);
  }
}

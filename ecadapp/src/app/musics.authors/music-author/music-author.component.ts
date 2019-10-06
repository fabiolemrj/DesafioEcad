import { Component, OnInit } from '@angular/core';
import {  ResponseAuthorResult,  ReqUpdateMusicAuthor } from '../music-author.model/music-author.model';
import { MusicAuthorService } from '../service/music.author.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MusicsService } from 'src/app/musics/musics.service';

@Component({
  selector: 'app-music-author',
  templateUrl: './music-author.component.html',
  styleUrls: ['./music-author.component.css']
})
export class MusicAuthorComponent implements OnInit {

  responseMusicAuthor: ResponseAuthorResult;
  
  id: string;
  constructor(private service: MusicAuthorService, private musicservice: MusicsService, private router: ActivatedRoute, private _router: Router) { }

  ngOnInit() {
    
    this.id = this.router.snapshot.paramMap.get('id');
   
    this.musicservice.getMusicById(this.id).subscribe(
      res => this.responseMusicAuthor.name = res.data.name
    );
  
    this.service.getById(this.id).subscribe(
      res => this.responseMusicAuthor = res
      
     );
     
    
  }

  getByIdMusic(id:string){
    this.service.getById(id).subscribe(
      res => this.responseMusicAuthor = res
     );


  
       }
}

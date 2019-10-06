import { Component, OnInit } from '@angular/core';
import { MusicsService } from './musics.service';
import { ResponseMusic } from "./music.model/ResponseMusic";

@Component({
  selector: 'app-musics',
  templateUrl: './musics.component.html',
  styleUrls: ['./musics.component.css']
})
export class MusicsComponent implements OnInit {

  responseMusics: ResponseMusic;
  constructor( private musicservice: MusicsService) { }

  ngOnInit() {
    this.musicservice.getMusicName('').subscribe(
     res => this.responseMusics = res
    );
   
  }

  pesquisar(id:string){
    this.musicservice.getMusicName(id).subscribe(
      res => this.responseMusics = res
     ); }

     
}

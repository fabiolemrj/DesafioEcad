import { Component, OnInit } from '@angular/core';
import { ReqCreateMusic, RespCreateMusic } from '../music.model/create.music.model';
import { MusicsService } from '../musics.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-create-music',
  templateUrl: './create-music.component.html',
  styleUrls: ['./create-music.component.css']
})
export class CreateMusicComponent implements OnInit {

  req: ReqCreateMusic ={
    name:'',
    code:'',
    genre:1
  };

  resp: RespCreateMusic;
  constructor(private service: MusicsService,  private _router: Router) { }

  ngOnInit() {

  }
  
  save(){
   
    this.service.createMusic(this.req).subscribe(res=>{     
      this.resp = res;
      this._router.navigate(['/music']);
    });    
  }

  cancel(){
    this._router.navigate(['/music']);
  }
}

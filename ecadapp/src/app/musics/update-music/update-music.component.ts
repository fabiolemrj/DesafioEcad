import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MusicsService } from '../musics.service';
import { ReqUpdateMusic } from '../music.model/update.music.model';

@Component({
  selector: 'app-update-music',
  templateUrl: './update-music.component.html',
  styleUrls: ['./update-music.component.css']
})
export class UpdateMusicComponent implements OnInit {

  id:string;
  req: ReqUpdateMusic;

  constructor(private  service:MusicsService, private router:ActivatedRoute, private _router: Router) { }

  ngOnInit() {
    this.id = this.router.snapshot.paramMap.get('id');
    this.service.getMusicById(this.id).subscribe(res => {
      this.req = {
        id: `${res.data.id}`,
        name: `${res.data.name}`,
        code: `${res.data.code}`,
        genre: Number(`${res.data.genre}`)
            }
    });
  }

  save(){
    this.service.updateMusic(this.id,this.req).subscribe(res =>{
      alert(`${this.req.name} salva com sucesso`);
      this._router.navigate(['/music']);

    });
  }

  cancel(){
    this._router.navigate(['/music']);
  }

}

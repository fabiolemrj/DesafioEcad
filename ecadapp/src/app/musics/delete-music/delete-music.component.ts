import { Component, OnInit } from '@angular/core';
import { MusicsService } from '../musics.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ReqUpdateMusic } from '../music.model/update.music.model';
import { Music } from '../music.model';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-delete-music',
  templateUrl: './delete-music.component.html',
  styleUrls: ['./delete-music.component.css']
})
export class DeleteMusicComponent implements OnInit {

  id: string;
  req: ReqUpdateMusic;
  music: Music;

  constructor(private  service: MusicsService, private router: ActivatedRoute, private _router: Router) { }

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

  delete(){
    this.service.deleteMusic(this.id).subscribe(res => {
      alert(`${this.req.name} removida com sucesso`);
      this._router.navigate(['/music']);
    });
  }

  cancel(){
    this._router.navigate(['/music']);
  }

}

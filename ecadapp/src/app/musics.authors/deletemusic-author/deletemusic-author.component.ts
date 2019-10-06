import { Component, OnInit } from '@angular/core';
import { ReqUpdateMusicAuthor, ReqMusicAuthorById } from '../music-author.model/delete-music.author.model';
import { MusicAuthor } from '../music-author.model/music-author.model';
import { MusicsService } from 'src/app/musics/musics.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MusicAuthorService } from '../service/music.author.service';
import { AuthorsService } from 'src/app/authors/services.authors/authors.service';

@Component({
  selector: 'app-deletemusic-author',
  templateUrl: './deletemusic-author.component.html',
  styleUrls: ['./deletemusic-author.component.css']
})
export class DeletemusicAuthorComponent implements OnInit {

  id: string;
  authorid:string;
  resp: ReqUpdateMusicAuthor;
  req: ReqMusicAuthorById;
  musicauthor: MusicAuthor;


  constructor(private  service: MusicAuthorService, 
    private musicservice: MusicsService, private authorservice:AuthorsService,
    private router: ActivatedRoute, private _router: Router) { }

  ngOnInit() {
    this.id = this.router.snapshot.paramMap.get('musicid');
    this.authorid = this.router.snapshot.paramMap.get('authorid');

    this.service.getMusicAuthorByIds(this.id, this.authorid).subscribe(res => {
      this.resp = {
        musicId: `${res.data.musicId}`,
        nameMusic: `${res.data.nameMusic}`,
        authorId: `${res.data.authorId}`,
        nameAuthor: `${res.data.nameAuthor}`,
        categoryAuthor: `${res.data.categoryAuthor}`
            };
    });
  }
  delete(){
    this.service.delete(this.id,this.authorid).subscribe(res => {
      alert(`${this.resp.nameAuthor} removido(a) com sucesso`);
      this._router.navigate(['/music']);
    });
  }

  cancel(){
    this._router.navigate(['/music']);
  }

}

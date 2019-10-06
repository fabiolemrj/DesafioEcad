import { Component, OnInit } from '@angular/core';
import { ReqCreateMusicAuthor, RespCreateMusicAuthor } from '../music-author.model/create.music-author.model';
import { MusicAuthorService } from '../service/music.author.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MusicsService } from 'src/app/musics/musics.service';
import { Author } from 'src/app/authors/authors.model/authors.model';
import { AuthorsService } from 'src/app/authors/services.authors/authors.service';

@Component({
  selector: 'app-createmusic-author',
  templateUrl: './createmusic-author.component.html',
  styleUrls: ['./createmusic-author.component.css']
})
export class CreatemusicAuthorComponent implements OnInit {

  req: ReqCreateMusicAuthor ={
    AuthorId:'',
    AuthorName:'',
    MusicName:'',
    MusicId:'',
    data: [{id:'',category: '',code:'',name:''}]
  };

  resp: RespCreateMusicAuthor;

  constructor(private service: MusicAuthorService, 
                private musicservice: MusicsService, private authorservice:AuthorsService,
                  private _router: Router, private router: ActivatedRoute) { }
  
  ngOnInit() {
    this.req.MusicId = this.router.snapshot.paramMap.get('id');
    
    this.authorservice.getAvailable(this.req.MusicId).subscribe(
      res => this.req.data = res.data
    );
    
    this.musicservice.getMusicById(this.req.MusicId).subscribe(
      res => this.req.MusicName = res.data.name
    );
  }

  save(){
    this.service.create(this.req).subscribe(res=>{
      this.resp = res;
      this._router.navigate([`/musicauthor/${this.req.MusicId}`]);
    });
  }

  cancel(){
    this._router.navigate([`/musicauthor/${this.req.MusicId}`]);

  }

}

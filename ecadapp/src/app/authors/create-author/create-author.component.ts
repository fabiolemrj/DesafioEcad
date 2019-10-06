import { Component, OnInit } from '@angular/core';
import { ReqCreateAuthor, RespCreateAuthor } from '../authors.model/create.authors.model';
import { Router } from '@angular/router';
import { AuthorsService } from '../services.authors/authors.service';

@Component({
  selector: 'app-create-author',
  templateUrl: './create-author.component.html',
  styleUrls: ['./create-author.component.css']
})
export class CreateAuthorComponent implements OnInit {

  req: ReqCreateAuthor ={
    name:'',
    code:'',
    category:1
  };

  resp: RespCreateAuthor;

  constructor(private service: AuthorsService,  private _router: Router) { }

  ngOnInit() {
  }

  save(){
   
    this.service.create(this.req).subscribe(res=>{     
      this.resp = res;
      this._router.navigate(['/author']);
    });    
  }

  cancel(){
    this._router.navigate(['/author']);
  }

}

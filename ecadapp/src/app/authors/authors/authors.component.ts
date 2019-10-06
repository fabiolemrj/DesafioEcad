import { Component, OnInit } from '@angular/core';
import { ResponseAuthor } from '../authors.model/authors.model';
import { AuthorsService } from '../services.authors/authors.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  responseAuthor: ResponseAuthor;
  constructor(private service: AuthorsService) { }

  ngOnInit() {
    this.service.getByName('').subscribe(
      res => this.responseAuthor = res
     );
  }

  pesquisar(id: string){
    this.service.getByName(id).subscribe(
      res => this.responseAuthor = res
     ); }


}

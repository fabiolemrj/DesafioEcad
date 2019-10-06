import { Component, OnInit } from '@angular/core';
import { AuthorsService } from '../services.authors/authors.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ReqUpdateAuthor } from '../authors.model/update.authors.model';
import { Author } from '../authors.model/authors.model';

@Component({
  selector: 'app-delete-author',
  templateUrl: './delete-author.component.html',
  styleUrls: ['./delete-author.component.css']
})
export class DeleteAuthorComponent implements OnInit {

  constructor(private  service: AuthorsService, private router: ActivatedRoute, private _router: Router) { }

  id: string;
  req: ReqUpdateAuthor;
  music: Author;

  ngOnInit() {
    this.id = this.router.snapshot.paramMap.get('id');
    this.service.getById(this.id).subscribe(res => {
      this.req = {
        id: `${res.data.id}`,
        name: `${res.data.name}`,
        code: `${res.data.code}`,
        category: Number(`${res.data.category}`)
            }
    });
  }

  delete(){
    this.service.delete(this.id).subscribe(res => {
      alert(`${this.req.name} removida com sucesso`);
      this._router.navigate(['/author']);
    });
  }

  cancel(){
    this._router.navigate(['/author']);
  }


}

import { Component, OnInit } from '@angular/core';
import { ReqUpdateAuthor } from '../authors.model/update.authors.model';
import { AuthorsService } from '../services.authors/authors.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-author',
  templateUrl: './update-author.component.html',
  styleUrls: ['./update-author.component.css']
})
export class UpdateAuthorComponent implements OnInit {

  id:string;
  req: ReqUpdateAuthor;
  constructor(private  service:AuthorsService, private router:ActivatedRoute, private _router: Router) { }

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

  save(){
    this.service.update(this.id,this.req).subscribe(res =>{
      alert(`${this.req.name} salva com sucesso`);
      this._router.navigate(['/author']);

    });
  }

  cancel(){
    this._router.navigate(['/author']);
  }

}

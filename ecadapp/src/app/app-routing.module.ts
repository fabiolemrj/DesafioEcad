import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MusicsComponent } from './musics/musics.component';

import { CreateMusicComponent } from './musics/create-music/create-music.component';
import { UpdateMusicComponent } from './musics/update-music/update-music.component';
import { DeleteMusicComponent } from './musics/delete-music/delete-music.component';
import { CreateAuthorComponent } from './authors/create-author/create-author.component';
import { AuthorsComponent } from './authors/authors/authors.component';
import { UpdateAuthorComponent } from './authors/update-author/update-author.component';
import { DeleteAuthorComponent } from './authors/delete-author/delete-author.component';
import { MusicAuthorComponent } from './musics.authors/music-author/music-author.component';
import { CreatemusicAuthorComponent } from './musics.authors/createmusic-author/createmusic-author.component';
import { DeletemusicAuthorComponent } from './musics.authors/deletemusic-author/deletemusic-author.component';
import { MainComponent } from './main/main.component';


const routes: Routes = [
  {path:'music',component:MusicsComponent},
  {path:'createmusic',component:CreateMusicComponent},
  {path:'updatemusic/:id',component:UpdateMusicComponent},
  {path:'deletemusic/:id',component:DeleteMusicComponent},
  {path:'createauthor',component:CreateAuthorComponent},
  {path:'author',component:AuthorsComponent},
  {path:'updateauthor/:id',component:UpdateAuthorComponent},
  {path:'deleteauthor/:id',component:DeleteAuthorComponent},
  {path:'musicauthor/:id',component:MusicAuthorComponent},
  {path:'createmusicauthor/:id',component:CreatemusicAuthorComponent},
  {path:'deletemusicauthor/:musicid/:authorid',component:DeletemusicAuthorComponent},
  {path:'main',component:MainComponent},
  {path: '', redirectTo: '/main', pathMatch: 'full' }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

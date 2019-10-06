import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MusicsComponent } from './musics/musics.component';
import {  HttpClientModule } from '@angular/common/http';
import { CreateMusicComponent } from './musics/create-music/create-music.component';
import { FormsModule } from '@angular/forms';
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


@NgModule({
  declarations: [
    AppComponent,
    MusicsComponent,
    CreateMusicComponent,
    UpdateMusicComponent,
    DeleteMusicComponent,
    CreateAuthorComponent,
    AuthorsComponent,
    UpdateAuthorComponent,
    DeleteAuthorComponent,
    MusicAuthorComponent,
    CreatemusicAuthorComponent,
    DeletemusicAuthorComponent,
    MainComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,  
    HttpClientModule, // import the module
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Author } from 'src/app/authors/authors.model/authors.model';

export interface ReqCreateMusicAuthor{
    MusicId: string;
    MusicName:string;
    AuthorId: string;
    AuthorName:string;
    data:Author[];
}


export interface RespCreateMusicAuthor {
    success: boolean;
    message: string;
    data: ReqCreateMusicAuthor;
}

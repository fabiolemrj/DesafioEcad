export interface MusicAuthor{
    MusicId: string;
    AuthorId: string;
}

export interface ResponseMusicAuthor {
    success: boolean;
    message: string;
    data: MusicAuthor[];
}

export interface MusicAuthorResult{
    ausicid: string;
    nameMusic: string;
    authorid: string;
    nameAuthor:string;
    categoryAuthor:string;
}

export interface ResponseAuthorResult {
    success: boolean;
    message: string;
    name: string;
    data: MusicAuthorResult[];
}

export interface ReqUpdateMusicAuthor{
    musicid: string;
    authorid: string;
    namemusic: string;
    nameauthor: string;
}
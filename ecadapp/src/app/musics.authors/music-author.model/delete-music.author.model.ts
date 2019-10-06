export interface RespGetMusicAuthor {
    
    data: ReqUpdateMusicAuthor;
}

export interface ReqMusicAuthorById{
    musicId: string;
    authorId: string;
}


export interface ReqUpdateMusicAuthor{
    musicId: string;
    nameMusic: string;
    authorId: string;
    nameAuthor: string;
    categoryAuthor: string;
}

export interface RespUpdateMusicAuthor {
    success: boolean;
    message: string;
    data: ReqUpdateMusicAuthor;
}

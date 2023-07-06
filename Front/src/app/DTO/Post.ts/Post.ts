export interface Post {
  id: number,
  tittle: string;
  postText: string;
  postDate: Date;
  forum: number;
  participant: number;
  upvote: number;
  downvote: number;
}


export interface ListParticipantsForum
{
  forum: number;
  Participant : number;
}

export interface InfoParticipant {
  id: number;
  nickName: string;
  role: string;
}

export interface RoleParticipant {
  userId: number;
  roleId: number;
  forumId: number;
}
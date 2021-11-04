export class Register{

  public constructor(init?: Partial<Register>) {
    Object.assign(this, init);
  }

  firstName: string;
  lastName: string;
  birthday: string;
  email: string;
  password: string;
}

export class Auth {

  public constructor(init?: Partial<Auth>) {
    Object.assign(this, init);
  }

  id: string;
  email: string;
  firstName: string;
  lastName: string;
  token: string;
  customerId: string;
}

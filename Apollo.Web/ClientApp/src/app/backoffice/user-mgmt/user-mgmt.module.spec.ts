import { UserMgmtModule } from './user-mgmt.module';

describe('UserMgmtModule', () => {
  let userMgmtModule: UserMgmtModule;

  beforeEach(() => {
    userMgmtModule = new UserMgmtModule();
  });

  it('should create an instance', () => {
    expect(userMgmtModule).toBeTruthy();
  });
});

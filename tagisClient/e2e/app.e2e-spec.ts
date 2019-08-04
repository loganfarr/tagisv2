import { TagisPage } from './app.po';

describe('tagis App', () => {
  let page: TagisPage;

  beforeEach(() => {
    page = new TagisPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

@echo off

set DIR_PATH=
set /P DIR_PATH="twapi�̃C���X�g�[����̃t�H���_�p�X����͂��Ă�������:"

set CONSUMER_KEY=
set /P CONSUMER_KEY="TwitterAPI�̃R���V���[�}�[�L�[����͂��Ă�������:"

set CONSUMER_SECRET=
set /P CONSUMER_SECRET="TwitterAPI�̃R���V���[�V�[�N���b�g����͂��Ă�������:"

set ACCESS_TOKEN=
set /P ACCESS_TOKEN="TwitterAPI�̃A�N�Z�X�g�[�N������͂��Ă�������:"

set ACCESS_SECRET=
set /P ACCESS_SECRET="TwitterAPI�̃A�N�Z�X�V�[�N���b�g����͂��Ă�������:"


cd %DIR_PATH%
twapi /regist -ck %CONSUMER_KEY% -cs %CONSUMER_SECRET% -at %ACCESS_TOKEN% -as %ACCESS_SECRET%

twapi /refresh

PAUSE
EXIT
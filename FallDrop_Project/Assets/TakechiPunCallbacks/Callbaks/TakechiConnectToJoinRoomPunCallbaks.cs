using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using TakechiPunCallbacks.InformationDisplay;

namespace TakechiPunCallbacks.ServerConnect.ToJoinRoom
{
    public class TakechiConnectToJoinRoomPunCallbaks : TakechiPunInformationDisplay
    {
        /// <summary>
        /// �Q�l����
        /// </summary>
        /// 
        /// �p��W
        /// https://doc.photonengine.com/ja-jp/pun/current/reference/glossary
        ////////////////////////////////////////////////////////////////////
        
        #region RoomCreate

        /// <summary>
        /// �������쐬���ē������� ���J�X�^���v���p�e�B�̐ݒ�\
        /// </summary>
        /// <remarks> �����̍쐬�@��́A���̂܂܂��̕����̓������܂��B</remarks>>
        /// <param name="roomName"></param>
        /// <param name="roomOptions"></param>
        /// <param name="customRoomProperties"> �v���p�e�B�[�̕ۊǂ���Ă���@ExitGames.Client.Photon.Hashtable </param>
        protected void CreateRoom(string roomName, RoomOptions roomOptions, ExitGames.Client.Photon.Hashtable customRoomProperties)
        {
            roomOptions.CustomRoomProperties = customRoomProperties;

            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.CreateRoom(roomName, roomOptions);
            }
        }

        /// <summary>
        /// �������쐬���ē������� ���J�X�^���v���p�e�B�̐ݒ�\
        /// </summary>
        /// <remarks> �����̍쐬�@��́A���̂܂܂��̕����̓������܂��B</remarks>>
        /// <param name="roomName"></param>
        /// <param name="roomOptions"></param>
        protected void CreateRoom( string roomName, RoomOptions roomOptions)
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.CreateRoom(roomName, roomOptions);
            }
        }

        #endregion

        #region RoomJoin

        /// <summary>
        /// ����̕����ɓ�������
        /// </summary>
        /// <param name ="targetRoomName"> �����̖��O </param>
        protected void JoinRoom(string targetRoomName)
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinRoom(targetRoomName);
            }
        }
        
        /// <summary>
        /// �����_���ȕ����ɓ�������
        /// </summary>
        protected void JoinRandomRoom()
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }

        #endregion

        #region RoomCreateOrJoin

        /// <summary>
        /// ���݂��Ȃ���΍쐬���ē������� 
        /// </summary>
        /// <remarks> 
        /// ���J�X�^���v���p�e�B�̐ݒ�\
        /// </remarks>>
        /// <param name="roomName"></param>
        /// <param name="roomOptions"></param>
        /// <param name="customRoomProperties"> �v���p�e�B�[�̕ۊǂ���Ă���@ExitGames.Client.Photon.Hashtable </param>
        protected void JoinOrCreateRoom( string roomName, RoomOptions roomOptions ,ExitGames.Client.Photon.Hashtable customRoomProperties)
        {
            roomOptions.CustomRoomProperties = customRoomProperties;

            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinOrCreateRoom( roomName, roomOptions, TypedLobby.Default);
            }
        }
        /// <summary>
        /// ���݂��Ȃ���΍쐬���ē�������
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="roomOptions"></param>
        protected void JoinOrCreateRoom( string roomName, RoomOptions roomOptions)
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinOrCreateRoom( roomName, roomOptions, TypedLobby.Default);
            }
        }

        #endregion

        #region active caollbaks

        /// <summary>
        /// �����ɓ���������
        /// </summary>
        /// <remarks>
        /// ���[���ɓ��������Ƃ��ɁA���̃N���C�A���g�����[�����쐬�������A�P�ɎQ���������Ɋ֌W�Ȃ��Ăяo����܂��B
        /// </remarks> 
        public override void OnJoinedRoom()
        {
            Debug.Log(" OnJoinedRoom :<color=green> clear</color>");
        }

        /// <summary>
        /// �������쐬������
        /// </summary>
        public override void OnCreatedRoom()
        {
            Debug.Log(" OnCreatedRoom :<color=green> clear</color>");
        }

        /// <summary>
        /// ��������ގ�������
        /// </summary>
        public override void OnLeftRoom()
        {
            Debug.Log(" OnLeftRoom :<color=green> clear</color>");
        }

        #endregion

        #region error callbaks

        /// <summary>
        /// ����̕����ւ̓����Ɏ��s������
        /// </summary>
        /// <remarks>�ڑ��Ɏ��s�����ꍇ�}�X�^�[�T�[�o�[�̌Ăяo���܂Ŗ߂�܂��B</remarks>>
        /// <param name="returnCode"> �T�[�o�[����̑���߂�R�[�h </param>
        /// <param name="message"> �G���[���b�Z�[�W </param>
        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogError(InformationTitleTemplate(" OnJoinRoomFailed ") +
                $" Massage : <color=red>{message}</color> CodeNumber : <color=red>{returnCode}</color>");
        }

        /// <summary>
        /// �����_���ȕ����ւ̓����Ɏ��s������
        /// </summary>
        /// <remarks>�ڑ��Ɏ��s�����ꍇ�}�X�^�[�T�[�o�[�̌Ăяo���܂Ŗ߂�܂��B</remarks>>
        /// <param name="returnCode"> �T�[�o�[����̑���߂�R�[�h </param>
        /// <param name="message"> �G���[���b�Z�[�W </param>
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.LogError(InformationTitleTemplate(" OnJoinRandomFailed ") +
                $" Massage : <color=red>{message}</color>  CodeNumber : <color=red>{returnCode}</color>");
        }

        /// <summary>
        /// �T�[�o�[�Ƀ��[�����쐬�ł��Ȃ������ꍇ 
        /// </summary>
        /// <remarks>
        /// The most common cause to fail creating a room, is when a title relies on fixed room-names and the room already exists.
        /// </remarks>
        /// <param name="returnCode"> �T�[�o�[����̑���߂�R�[�h </param>
        /// <param name="message"> �G���[���b�Z�[�W </param>
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.LogError(InformationTitleTemplate(" OnCreateRoomFailed ") +
               $" Massage : <color=red>{message}</color> CodeNumber : <color=red>{returnCode}</color>");
        }

        #endregion
    }
}

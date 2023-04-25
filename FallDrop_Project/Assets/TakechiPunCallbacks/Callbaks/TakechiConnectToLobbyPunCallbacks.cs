using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TakechiPunCallbacks.InformationDisplay;

namespace TakechiPunCallbacks.ServerConnect.ToLobby
{
    public class TakechiConnectToLobbyPunCallbacks : TakechiPunInformationDisplay
    {
        /// <summary>
        /// �Q�l����
        /// </summary>
        /// 
        /// �p��W
        /// https://doc.photonengine.com/ja-jp/pun/current/reference/glossary
        ////////////////////////////////////////////////////////////////////
        
        #region Connect
        /// <summary>
        /// Photon�ɐڑ�����
        /// </summary>
        /// <param name ="gameVersion"> �o�[�W���� </param>
        public void Connect(string gameVersion)
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
            else
            {
                Debug.LogWarning("Connection will not be performed because it was in a connected state.");
            }
        }
        #endregion

        #region JoinLobby
        /// <summary>
        /// ���r�[�ɓ���
        /// </summary>
        protected void JoinLobby()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinLobby();
            }
        }

        #endregion

        #region active callbacks

        /// <summary>
        /// Photon�ɐڑ�������
        /// </summary>
        public override void OnConnected()
        {
            Debug.Log(" OnConnected :<color=green> clear</color>");
        }

        /// <summary>
        /// �}�X�^�[�T�[�o�[�ɐڑ�������
        /// </summary>
        public override void OnConnectedToMaster()
        {
            Debug.Log(" OnConnectedToMaster :<color=green> clear</color>");
        }

        /// <summary>
        /// ���r�[�ɓ�������
        /// </summary>
        public override void OnJoinedLobby()
        {
            Debug.Log(" OnJoinedLobby :<color=green> clear</color>");
        }

        /// <summary>
        /// ���r�[����o����
        /// </summary>
        public override void OnLeftLobby()
        {
            Debug.Log(" OnLeftLobby :<color=green> clear</color>");
        }

        /// <summary>
        /// ���r�[�ɍX�V����������
        /// </summary>
        /// <param name="lobbyStatistics">
        /// ���r�[�̏��
        /// 
        /// �Q�l
        /// https://doc-api.photonengine.com/ja-jp/pun/v2/class_photon_1_1_realtime_1_1_typed_lobby_info.html
        /// </param>
        public override void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
            Debug.Log("OnLobbyStatisticsUpdate");
        }

        /// <summary>
        /// ���[���ɓ��������������́A���X�g�ɍX�V����������
        /// </summary>
        /// <param name="roomList">
        /// 
        /// ���[���̏��
        /// �Q�l
        /// https://doc-api.photonengine.com/ja-jp/pun/v2/class_photon_1_1_realtime_1_1_room_info.html
        /// </param>
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log(" OnRoomListUpdate :<color=green> clear </color>");

            foreach (RoomInfo roomInfo in roomList)
            {
                
            }
        }

        #endregion
    }
}

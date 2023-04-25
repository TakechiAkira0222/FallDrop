using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Photon.Realtime;
using Photon.Pun;

using TakechiPunCallbacks.InformationDisplay;

namespace TakechiPunCallbacks.ServerConnect.Joined
{
    public class TakechiJoinedPunCallbacks : TakechiPunInformationDisplay
    {
        /// <summary>
        /// �Q�l����
        /// </summary>
        /// 
        /// �p��W
        /// https://doc.photonengine.com/ja-jp/pun/current/reference/glossary
        ////////////////////////////////////////////////////////////////////

        #region LeaveRoom

        /// <summary>
        /// ��������ގ�����
        /// </summary>
        protected void LeaveRoom()
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();
                Debug.Log(" OnLeaveRoom :<color=green> clear </color>", this.gameObject);
            }
        }

        #endregion

        /// <summary>
        /// �}�X�^�[�N���C�A���g���ς������
        /// </summary>
        /// <remarks>
        /// ���̃N���C�A���g�����[���ɓ���Ƃ��A����͌Ăяo����܂���B 
        /// ���̃��\�b�h���Ăяo���ꂽ�Ƃ��A�ȑO�̃}�X�^�[ �N���C�A���g�̓v���C���[ ���X�g�Ɏc���Ă��܂��B
        /// </remarks>
        /// <param name="newMasterClient"></param>
        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            PlayerInformationDisplay(newMasterClient, "OnMasterClientSwitched");
        }

        /// <summary>
        /// ���[���v���p�e�B���X�V���ꂽ��
        /// </summary>
        /// <param name="propertiesThatChanged">
        ///�@���[���v���p�e�B
        /// </param>
        /// <remarks>�@�v���p�e�B�[�ɍX�V�����������A�X�V���ꂽKey�̕ύX���e��Ԃ��܂��B</remarks>>
        public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
        {
            // �X�V���ꂽ�v���C���[�̃J�X�^���v���p�e�B�̃y�A���R���\�[���ɏo�͂���
            foreach (var prop in propertiesThatChanged)
            {
                Debug.Log($" Room property <color=orange>'{prop.Key}'</color> : <color=blue>{prop.Value}</color> <color=green>changed.</color>");
            }

            Debug.Log($"OnRoomPropertiesUpdate :<color=green> clear </color>", this.gameObject);
        }

        /// <summary>
        /// �v���C���[�v���p�e�B���X�V���ꂽ��
        /// </summary>
        /// <param name="target">
        /// 
        /// �v���C���[�̃f�[�^
        /// �Q�l
        /// https://doc-api.photonengine.com/ja-jp/pun/v2/class_photon_1_1_realtime_1_1_player.html
        /// </param>
        /// <param name="changedProps">
        /// ���[���v���p�e�B
        /// </param>
        public override void OnPlayerPropertiesUpdate(Player target, ExitGames.Client.Photon.Hashtable changedProps)
        {
            // �X�V���ꂽ�v���C���[�̃J�X�^���v���p�e�B�̃y�A���R���\�[���ɏo�͂���
            foreach (var prop in changedProps)
            {
                Debug.Log($" Player property <color=orange>'{prop.Key}'</color> : <color=blue>{prop.Value}</color> <color=green>changed.</color>");
            }

            Debug.Log($"OnRoomPropertiesUpdate :<color=green> clear </color>");
        }

        /// <summary>
        /// ���̃v���C���[���������Ă�����
        /// </summary>
        /// <param name="newPlayer">
        /// �v���C���[�̃f�[�^
        /// �Q�l
        /// https://doc-api.photonengine.com/ja-jp/pun/v2/class_photon_1_1_realtime_1_1_player.html
        /// </param>
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            PlayerInformationDisplay(newPlayer, "OnPlayerEnteredRoom");
        }

        /// <summary>
        /// ���̃v���C���[���ގ�������
        /// </summary>
        /// <param name="otherPlayer">
        /// �v���C���[�̃f�[�^
        /// �Q�l
        /// https://doc-api.photonengine.com/ja-jp/pun/v2/class_photon_1_1_realtime_1_1_player.html
        /// </param>
        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            PlayerInformationDisplay(otherPlayer, "OnPlayerLeftRoom");
        }
    }
}
